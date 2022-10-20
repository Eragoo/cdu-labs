package com.Eragoo.cdu_labs

import android.annotation.SuppressLint
import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity


class MainActivity : AppCompatActivity() {
    var counter = 0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        setContentView(R.layout.activity_main)

        val incrementTextView = findViewById<TextView>(R.id.Increment_text_view)

        val incrementButton = findViewById<Button>(R.id.Increment_button)
        incrementButton.setOnClickListener { v ->
            val text = getString(R.string.my_own_text, ++counter)
            incrementTextView.text = text
        }
    }
}