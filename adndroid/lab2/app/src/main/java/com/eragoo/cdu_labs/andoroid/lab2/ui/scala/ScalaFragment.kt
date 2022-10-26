package com.eragoo.cdu_labs.andoroid.lab2.ui.scala

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import com.eragoo.cdu_labs.andoroid.lab2.databinding.FragmentScalaBinding

class ScalaFragment : Fragment() {

    private var _binding: FragmentScalaBinding? = null

    // This property is only valid between onCreateView and
    // onDestroyView.
    private val binding get() = _binding!!

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        val slideshowViewModel =
            ViewModelProvider(this).get(ScalaViewModel::class.java)

        _binding = FragmentScalaBinding.inflate(inflater, container, false)
        val root: View = binding.root

        val textView: TextView = binding.textScala
        slideshowViewModel.text.observe(viewLifecycleOwner) {
            textView.text = it
        }
        return root
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}