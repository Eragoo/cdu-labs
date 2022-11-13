package com.eragoo.cdu_labs.andoroid.lab3.viewmodel

import android.app.Application
import androidx.lifecycle.AndroidViewModel
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.viewModelScope
import com.eragoo.cdu_labs.andoroid.lab3.RetrofitClient
import com.eragoo.cdu_labs.andoroid.lab3.model.ApplicationDatabase
import com.eragoo.cdu_labs.andoroid.lab3.model.User
import kotlinx.coroutines.DelicateCoroutinesApi
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import java.util.UUID

class UserViewModel(application: Application) : AndroidViewModel(application) {
    private val _usersLiveData = MutableLiveData<List<User>>()
    private val usersDataBase = ApplicationDatabase.getInstance(application).userDao()
    val users = usersDataBase.getAllUsersLiveData()

    init {
        viewModelScope.launch {
            insertUsersToDataBase()
        }
        viewModelScope.launch(Dispatchers.Main) {
            loadUsersData()
        }
    }

    private suspend fun loadUsersData() {
        _usersLiveData.value = usersDataBase.getAll()
    }

    private suspend fun insertUsersToDataBase() {
        GlobalScope.launch {
            val users = RetrofitClient.userApi.getAll();
            users.body()?.map { User(UUID.randomUUID().toString(), it.firstName, it.lastName, it.email)}?.toTypedArray()
                ?.let { usersDataBase.insertAll(*it) }
        }
    }
}