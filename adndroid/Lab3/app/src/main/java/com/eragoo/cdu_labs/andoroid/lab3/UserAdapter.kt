package com.eragoo.cdu_labs.andoroid.lab3

import android.app.Application
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import androidx.recyclerview.widget.DiffUtil
import androidx.recyclerview.widget.ListAdapter
import androidx.recyclerview.widget.RecyclerView
import com.eragoo.cdu_labs.andoroid.lab3.model.ApplicationDatabase
import com.eragoo.cdu_labs.andoroid.lab3.model.User
import com.eragoo.cdu_labs.andoroid.lab3.model.UserDao

class UserAdapter(application: Application) :
    ListAdapter<User, UserAdapter.UserHolder>(object : DiffUtil.ItemCallback<User>() {
        override fun areItemsTheSame(
            oldItem: User,
            newItem: User
        ): Boolean = oldItem.uid == newItem.uid

        override fun areContentsTheSame(
            oldItem: User,
            newItem: User
        ): Boolean = oldItem == newItem
    }) {

    private val db: UserDao = ApplicationDatabase.getInstance(application).userDao()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): UserHolder {
        val layoutInflater = LayoutInflater.from(parent.context)
        val view = layoutInflater.inflate(R.layout.recyclerview_item, parent, false)
        return UserHolder(view)
    }

    override fun onBindViewHolder(holder: UserHolder, position: Int) {
        holder.bind(getItem(position))
        holder.deleteButton.setOnClickListener { v ->
            val p = position;
            val theRemovedItem = getItem(p);
            println(theRemovedItem)
            db.delete(theRemovedItem)
            notifyItemRemoved(p)
            notifyItemRangeChanged(0, currentList.size)
        }
    }

    inner class UserHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        private val nameView: TextView = itemView.findViewById(R.id.textViewLarge)
        private val emailView: TextView = itemView.findViewById(R.id.textViewSmall)
        private val id: TextView = itemView.findViewById(R.id.id)
        fun bind(item: User) {
            nameView.text = item.firstName + " " + item.lastName
            emailView.text = item.email
            id.text = item.uid
        }

        val deleteButton: Button = itemView.findViewById(R.id.deleteUserButton)
    }
}
