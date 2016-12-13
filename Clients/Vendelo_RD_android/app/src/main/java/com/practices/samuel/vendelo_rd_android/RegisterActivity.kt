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

    val httpHandler = HttpHandler()
    val gson = Gson()

    fun StoreUserData(serverResponse: String?) {
        val preferences = getSharedPreferences("UserData", 0)
        val newUser = gson.fromJson(serverResponse, Usuario::class.java)
        val editor = preferences.edit()
        editor.putString("userEmail", newUser.email)
        editor.putString("userName", newUser.displayName)
        editor.putString("jwt", newUser.token)
        editor.commit()
    }

    fun Register(view: View) {
        val newUser = getNewUsuario()
        var userCredentialsJSON = gson.toJson(newUser)

        httpHandler.PostHttpData("http://10.0.0.21:3000/api/Auth/LocalRegister", userCredentialsJSON).subscribe(fun(it) {
            //httpTextView.text=it
            if (!it.contentEquals("User already registered")) {

                StoreUserData(it)
            }

        }, fun(it) {
                it.printStackTrace()
            })
    }

    private fun getNewUsuario(): Usuario {
        var email = editCorreo.text.toString()
        var displayName = editNombre.text.toString()
        var password = editPassword.text.toString()
        val newUser = Usuario(email, displayName, password)
        return newUser
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.register_activity)

        val jwt = getSharedPreferences("UserData", 0)?.getString("jwt", "")
        if (!jwt.isNullOrEmpty()) {
            goToAdsActivity()
        }

    }

    fun goToAdsActivity() {

        val redirect = Intent(this, AdsDisplayActivity::class.java)

        startActivity(redirect)
    }
}
