package com.eragoo.cdu_labs.andoroid.lab2.ui.scala

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel

class ScalaViewModel : ViewModel() {

    private val _text = MutableLiveData<String>().apply {
        value = "Learn about Scala: https://www.scala-lang.org/"
    }
    val text: LiveData<String> = _text
}