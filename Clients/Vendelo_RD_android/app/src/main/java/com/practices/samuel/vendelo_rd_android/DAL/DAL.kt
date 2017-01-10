package com.practices.samuel.vendelo_rd_android.DAL

import com.google.gson.Gson
import com.practices.samuel.vendelo_rd_android.HttpHandler
import rx.Observable
import java.util.*

/**
 * Created by Samuel on 12/23/2016.
 */
class DAL {
    private val httpHandler = HttpHandler()

    fun GetAll(jwt:String,onSuccess: (String) -> Unit, onError: (String) -> Unit  )  {

        httpHandler.getHttpData("http://10.0.0.12:3000/api/Ads/GetAllAdds",jwt).subscribe(
                { serverResponse ->
                    onSuccess(serverResponse)
                },
                { error ->
                    error.printStackTrace()
                   onError(error.toString())
                })
    }

}