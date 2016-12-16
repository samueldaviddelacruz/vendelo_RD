package com.practices.samuel.vendelo_rd_android

import android.content.Intent
import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import com.practices.samuel.vendelo_rd_android.Model.Usuario
import kotlinx.android.synthetic.main.activity_login.*

class LoginActivity : AppCompatActivity() {

    val authManager = AuthManager(this)
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)
    }


    fun login(view: View) {
        authManager.Login(editCorreo.text.toString(), editPassword.text.toString(), onSuccess, onError)
    }

    var onSuccess = fun(serverResponse: String) {
        //labelError.text=serverResponse
        goToAdsActivity()
    }

    var onError = fun(error: String) {
        labelError.text = error
    }

    fun goToAdsActivity() {
        val redirect = Intent(this, AdsDisplayActivity::class.java)
        startActivity(redirect)
    }
}
