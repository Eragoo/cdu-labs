package com.eragoo.cdu_labs.andoroid.lab3

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetrofitClient {
    val userApi: UsersApi = Retrofit.Builder()
        .addConverterFactory(GsonConverterFactory.create())
        .baseUrl("https://raw.githubusercontent.com/")
        .build()
        .create(UsersApi::class.java)
}