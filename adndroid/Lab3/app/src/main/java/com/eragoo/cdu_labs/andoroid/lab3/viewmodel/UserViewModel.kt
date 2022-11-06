package com.eragoo.cdu_labs.andoroid.lab3.viewmodel

import android.app.Application
import androidx.lifecycle.AndroidViewModel
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.viewModelScope
import com.eragoo.cdu_labs.andoroid.lab3.model.ApplicationDatabase
import com.eragoo.cdu_labs.andoroid.lab3.model.DefaultUsersData
import com.eragoo.cdu_labs.andoroid.lab3.model.User
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch

class UserViewModel(application: Application) : AndroidViewModel(application) {
    private val userData: DefaultUsersData = DefaultUsersData();
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
        userData.data.forEach {
            usersDataBase.insertAll(it)
        }
    }
}