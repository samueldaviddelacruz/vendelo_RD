package com.practices.samuel.vendelo_rd_android

import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import android.view.DragEvent
import android.view.View
import kotlinx.android.synthetic.main.activity_main.*
import okhttp3.MediaType
import okhttp3.OkHttpClient
import okhttp3.Request
import rx.Observable
import rx.Scheduler
import rx.android.schedulers.AndroidSchedulers
import rx.lang.kotlin.*
import rx.schedulers.Schedulers
import java.io.IOException
import java.util.*
import kotlin.concurrent.thread
import okhttp3.RequestBody



class MainActivity : AppCompatActivity() {

    val httpHandler = HttpHandler()
    var userCredentialsJSON = """{"email":"androidtest@hotmail.com",
  "password":"123456"
}"""
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)




        httpHandler.getHttpData("https://remoteok.io/index.json","").subscribe({
             //httpTextView.text=it
        },{
            it.printStackTrace()
        })

        button.setOnClickListener{
            httpHandler.PostHttpData("http://10.0.0.21:3000/api/Auth/LocalRegister",userCredentialsJSON).subscribe({
                httpTextView.text=it
            },{
                it.printStackTrace()
            })
        }





    }
}
