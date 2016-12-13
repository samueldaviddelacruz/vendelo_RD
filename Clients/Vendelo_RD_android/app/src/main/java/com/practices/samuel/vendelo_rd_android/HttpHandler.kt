package com.practices.samuel.vendelo_rd_android
import okhttp3.MediaType
import okhttp3.OkHttpClient
import okhttp3.Request
import okhttp3.RequestBody
import rx.Observable
import rx.android.schedulers.AndroidSchedulers
import rx.lang.kotlin.observable
import rx.schedulers.Schedulers
import java.io.IOException

/**
 * Created by samuel on 12/13/16.
 */
class HttpHandler {
    private val client = OkHttpClient()
    private val JSON = MediaType.parse("application/json; charset=utf-8")
    private var jwt = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhbmRyb2lkdGVzdEBob3RtYWlsLmNvbSIsImV4cCI6MTMwMDgxOTM4MH0.nIIGhQel29e2hjLm2UHbS7x9XtgHSPTtFxvXO0giOfQ"

    @Throws(IOException::class)
    fun getHttpData(url:String,jwt:String):Observable<String>{

        return runOnMainThreadAsync<String> {
            val request = Request.Builder()
                    .url(url)
                    .addHeader("Authorization","Bearer $jwt")
                    .build()
            val response = client.newCall(request).execute()
            response.body().string()
        }
    }

    @Throws(IOException::class)
    fun PostHttpData(url: String, json: String): Observable<String> {

        return runOnMainThreadAsync<String> {
            val body = RequestBody.create(JSON, json)
            val request = Request.Builder()
                    .url(url)
                    .post(body)
                    .build()
            val response = client.newCall(request).execute()
            response.body().string()
        }

    }

    private fun <T>runOnMainThreadAsync(task:()->T): Observable<T> {
        return observable<T> {
            it.onNext(task())
            it.onCompleted()
        }.subscribeOn(Schedulers.io()).observeOn(AndroidSchedulers.mainThread())
    }


}