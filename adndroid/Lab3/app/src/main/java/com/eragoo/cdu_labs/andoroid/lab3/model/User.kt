package com.eragoo.cdu_labs.andoroid.lab3.model

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey

//https://raw.githubusercontent.com/Eragoo/cdu-labs/master/adndroid/users.json
@Entity
data class User(
    @PrimaryKey val uid: String,
    @ColumnInfo(name = "first_name") val firstName: String,
    @ColumnInfo(name = "last_name") val lastName: String,
    @ColumnInfo(name = "email") val email: String
)
