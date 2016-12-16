package com.practices.samuel.vendelo_rd_android

import android.content.ContextWrapper
import android.view.View
import com.google.gson.Gson
import com.practices.samuel.vendelo_rd_android.Model.Usuario
import kotlinx.android.synthetic.main.register_activity.*

/**
 * Created by Samuel on 12/16/2016.
 */
class AuthManager(private val context: ContextWrapper) {

    private val httpHandler = HttpHandler()
    private val gson = Gson()

    private fun StoreUserData(serverResponse: String?) {
        val preferences = context.getSharedPreferences("UserData", 0)
        val newUser = gson.fromJson(serverResponse, Usuario::class.java)
        val editor = preferences.edit()
        editor.putString("userEmail", newUser.email)
        editor.putString("userName", newUser.displayName)
        editor.putString("jwt", newUser.token)
        editor.commit()
    }


    private val onError = fun(error: Throwable) {
        error.printStackTrace()
    }

    fun Register(email: String, displayName: String, password: String, onSuccess: (String) -> Unit, onError: (String) -> Unit) {
        var userCredentialsJSON = getUserCredentialsJSON(displayName, email, password)

        httpHandler.PostHttpData("http://10.0.0.12:3000/api/Auth/LocalRegister", userCredentialsJSON).subscribe({ serverResponse ->
            if (!serverResponse.contains("User already registered")) {

                StoreUserData(serverResponse)
                onSuccess(serverResponse)

            } else {
                onError("User already registered")
            }
        }, { error ->
            error.printStackTrace()

            onError(error.toString())
        })


    }

    private fun getUserCredentialsJSON(displayName: String, email: String, password: String): String {
        val newUser = getNewUsuario(email, displayName, password)
        var userCredentialsJSON = gson.toJson(newUser)
        return userCredentialsJSON
    }

    fun Login(email: String, password: String, onSuccess: (String) -> Unit, onError: (String) -> Unit) {

        var userCredentialsJSON = getUserCredentialsJSON("", email, password)
        httpHandler.PostHttpData("http://10.0.0.12:3000/api/Auth/LocalLogin", userCredentialsJSON).subscribe(
                { serverResponse ->
                    if (serverResponse.contains("Invalid Username/password")) {

                        onError(serverResponse)
                    } else {
                        StoreUserData(serverResponse)
                        onSuccess(serverResponse)
                    }
                },
                { error ->
                    error.printStackTrace()
                    onError(error.toString())
                })
    }


    fun userHasAccesToken(): Boolean {
        val preferences = context.getSharedPreferences("UserData", 0)
        val jwt = preferences.getString("jwt", "")
        return !jwt.isNullOrEmpty()
    }

    private fun getNewUsuario(email: String, displayName: String, password: String): Usuario {
        var email = email
        var displayName = displayName
        var password = password
        val newUser = Usuario(email, displayName, password)
        return newUser
    }

    fun getUserFromStorage(): Usuario {
        val preferences = context.getSharedPreferences("UserData", 0)
        val email = preferences.getString("userEmail", "")
        val displayName = preferences.getString("userName", "")
        val newUser = Usuario(email, displayName, "")

        return newUser
    }


}
