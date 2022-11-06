package com.eragoo.cdu_labs.andoroid.lab3.viewmodel

import android.app.Application
import androidx.lifecycle.AndroidViewModel
import androidx.lifecycle.viewModelScope
import com.eragoo.cdu_labs.andoroid.lab3.model.ApplicationDatabase
import com.eragoo.cdu_labs.andoroid.lab3.model.User
import kotlinx.coroutines.launch
import java.util.regex.Matcher
import java.util.regex.Pattern

class AddUserViewModel(application: Application) : AndroidViewModel(application) {
    private val db = ApplicationDatabase.getInstance(application).userDao()

    fun insertUser(user: User) {
        viewModelScope.launch {
            db.insertAll(user)
        }
    }
}