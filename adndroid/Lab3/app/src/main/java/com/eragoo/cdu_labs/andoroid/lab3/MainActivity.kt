package com.eragoo.cdu_labs.andoroid.lab3

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView

class MainActivity : AppCompatActivity() {
    val emptyList = listOf(
        UserDto("Taras", "Schwartz", "taras@gmail.com"),
        UserDto("Ivan", "Ivanchenko", "ivan@gmail.com"),
        UserDto("Petro", "Petrenko", "petrenko@mail.com"),
        UserDto("Ihor", "Ihorovych", "ihor@yahoo.com"),
        UserDto("Oleh", "Oleksiyenko", "oleksiyenko@gmal.com"),
        UserDto("Vasyl", "Vasyliv", "vasyliv@gmail.com"),
        UserDto("Oleksandr", "Oleksandrovych", "Oleksandrovych@gmail.com"),
        UserDto("Andriy", "Andriyiv", "Andriyiv@gmail.com"),
        UserDto("Mykola", "Mykolayiv", "Mykolayiv@gmail.com"),
        UserDto("Vitaliy", "Vitaliyiv", "Vitaliyiv@gmail.com"),
        UserDto("Roman", "Romaniv", "roma@gmail.com"),
        UserDto("Yaroslav", "Yaroslaviv", "yarik@gmail.com"),
        UserDto("Yevhen", "Yevheniv", "eragoo@gmail.com"),
        UserDto("Yuriy", "Yuriyiv", "yuti@ukrnet.ua"),
        UserDto("Dmytro", "Dmytroiv", "dima@gmail.com"),
        UserDto("Taras", "Schwartz", "taras@gmail.com"),
        UserDto("Ivan", "Ivanchenko", "ivan@gmail.com"),
        UserDto("Petro", "Petrenko", "petrenko@mail.com"),
        UserDto("Ihor", "Ihorovych", "ihor@yahoo.com"),
        UserDto("Oleh", "Oleksiyenko", "oleksiyenko@gmal.com")
    )

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)


        val recyclerView: RecyclerView = findViewById(R.id.recycleView)
        recyclerView.layoutManager = LinearLayoutManager(this)
        recyclerView.adapter = RecyclerAdapter(emptyList)
    }
}