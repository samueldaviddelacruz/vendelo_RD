package com.practices.samuel.vendelo_rd_android

import android.content.Intent
import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import kotlinx.android.synthetic.main.activity_ads_display.*
import android.widget.ArrayAdapter
import android.widget.Toast
import com.google.gson.Gson
import com.google.gson.reflect.TypeToken
import com.practices.samuel.vendelo_rd_android.DAL.DAL
import com.practices.samuel.vendelo_rd_android.Model.Ad


class AdsDisplayActivity : AppCompatActivity() {
    val authManager = AuthManager(this)
    private val gson = Gson()
    var ads = emptyList<Ad>()
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


        if (authManager.userHasAccesToken()) {

            val user = authManager.getUserFromStorage()
            val dal= DAL()

            dal.GetAll(user.token,onAds,onError)

            textWelcome.text = "Bienvenido ${user.displayName}"
        }

    }
    var onAds =fun(adsJSONresponse:String){
        val listType = object : TypeToken<List<Ad>>() {

        }.type
        ads = gson.fromJson(adsJSONresponse,listType)


    }
    var onError =fun(error:String){



    }

    fun goToLogin(view: View) {
        val redirect = Intent(this, LoginActivity::class.java)

        startActivity(redirect)
    }
}
