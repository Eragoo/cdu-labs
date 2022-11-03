package com.eragoo.cdu_labs.andoroid.lab3

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.eragoo.cdu_labs.andoroid.lab3.dal.UserDto

class RecyclerAdapter(private val data: List<UserDto>) : RecyclerView.Adapter<RecyclerAdapter.MyViewHolder>() {
    class MyViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView){
        val largeTextView: TextView = itemView.findViewById(R.id.textViewLarge)
        val smallTextView: TextView = itemView.findViewById(R.id.textViewSmall)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): RecyclerAdapter.MyViewHolder {
        val itemView = LayoutInflater.from(parent.context)
                .inflate(R.layout.recyclerview_item, parent, false)

        return MyViewHolder(itemView)
    }

    override fun getItemCount() = data.size
    override fun onBindViewHolder(holder: MyViewHolder, position: Int) {
        holder.largeTextView.text = data[position].name + " " + data[position].surname
        holder.smallTextView.text = data[position].email
    }
}
