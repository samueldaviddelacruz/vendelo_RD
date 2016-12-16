package com.practices.samuel.vendelo_rd_android

import android.content.Intent
import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.View
import com.google.gson.Gson
import com.practices.samuel.vendelo_rd_android.Model.Usuario
import kotlinx.android.synthetic.main.register_activity.*


class RegisterActivity : AppCompatActivity() {


    val authManager = AuthManager(this)


    fun Register(view: View) {

        authManager.Register(editCorreo.text.toString(), editNombre.text.toString(), editPassword.text.toString(), onSuccess, onError)

    }

    var onSuccess = fun(serverResponse: String) {
        goToAdsActivity()
    }
    var onError = fun(serverResponse: String) {

    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.register_activity)


        if (authManager.userHasAccesToken()) {
            goToAdsActivity()
        }

    }


    fun goToAdsActivity() {

        val redirect = Intent(this, AdsDisplayActivity::class.java)

        startActivity(redirect)
    }

    fun goToLoginActivity(view: View) {

        val redirect = Intent(this, LoginActivity::class.java)

        startActivity(redirect)
    }
}
