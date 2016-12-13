package com.practices.samuel.vendelo_rd_android

import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import kotlinx.android.synthetic.main.activity_ads_display.*
import android.widget.ArrayAdapter
import android.widget.Toast


class AdsDisplayActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_ads_display)

        val values = arrayOf("Android List View",
                "Adapter implementation",
                "Simple List View In Android",
                "Create List View Android",
                "Android Example",
                "List View Source Code",
                "List View Array Adapter",
                "Android Example List View")

        val adapter = ArrayAdapter(this,
                android.R.layout.simple_list_item_1, android.R.id.text1, values)

        listViewAds.adapter = adapter


        listViewAds.setOnItemClickListener { parent, view, position, id ->
            // ListView Clicked item index
            val itemPosition = position

            // ListView Clicked item value

            // Show Alert
            Toast.makeText(applicationContext,
                    "Position :$itemPosition  ListItem : ${listViewAds.getItemAtPosition(position)}", Toast.LENGTH_LONG)
                    .show()


        }


    }
}
