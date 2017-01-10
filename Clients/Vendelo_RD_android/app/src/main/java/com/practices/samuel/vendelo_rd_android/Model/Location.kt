package com.practices.samuel.vendelo_rd_android.Model

/**
 * Created by Samuel on 12/23/2016.
 */
class Location(longitude:Double,latitude:Double) {
    val type:String="Point"
    val coordinates:DoubleArray = doubleArrayOf(0.0, 0.0)

    init{
        coordinates[0]=longitude
        coordinates[1]=latitude
    }

    fun getLongitude(): Double {
        return coordinates[0]
    }

    fun getLatitude(): Double {
        return coordinates[1]
    }
}