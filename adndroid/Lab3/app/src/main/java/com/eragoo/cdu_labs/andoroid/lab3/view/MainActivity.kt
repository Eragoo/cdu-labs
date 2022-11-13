package com.eragoo.cdu_labs.andoroid.lab3.view

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.Menu
import android.view.MenuItem
import android.widget.Button
import android.widget.TextView
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.eragoo.cdu_labs.andoroid.lab3.R
import com.eragoo.cdu_labs.andoroid.lab3.UserAdapter
import com.eragoo.cdu_labs.andoroid.lab3.model.ApplicationDatabase
import com.eragoo.cdu_labs.andoroid.lab3.model.User
import com.eragoo.cdu_labs.andoroid.lab3.viewmodel.AddUserViewModel
import com.eragoo.cdu_labs.andoroid.lab3.viewmodel.UserViewModel

class MainActivity : AppCompatActivity() {
    private lateinit var viewModel: UserViewModel

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val recyclerView: RecyclerView = findViewById(R.id.recycleView)
        recyclerView.layoutManager = LinearLayoutManager(this)
        val adapter = UserAdapter(this.application)
        recyclerView.adapter = adapter

        viewModel = ViewModelProvider(this)[UserViewModel::class.java]

        viewModel.users.observe(this) {
            it?.let {
                adapter.submitList(it)
            }
        }
    }

    override fun onCreateOptionsMenu(menu: Menu?): Boolean {
        menuInflater.inflate(R.menu.user_list, menu)
        return super.onCreateOptionsMenu(menu)
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        when (item.itemId) {
            R.id.addButton -> {
                val intent = Intent(this, AddUserActivity::class.java)
                startActivity(intent)
            }
        }
        return super.onOptionsItemSelected(item)
    }
}