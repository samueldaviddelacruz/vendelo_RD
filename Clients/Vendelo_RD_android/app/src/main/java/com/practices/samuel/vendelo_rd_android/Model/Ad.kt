package com.practices.samuel.vendelo_rd_android.Model

import java.util.*

/**
 * Created by Samuel on 12/23/2016.
 */
class Ad() : MongoEntity() {
    var categoryId:String = ""
    var title:String = ""
    var description:String=""
    var price:Double=0.0
    var pictures:List<ByteArray> =  emptyList<ByteArray>()
    var location:Location=Location(0.0,0.0)
    var usuario: Usuario? = null
    var uploadDate:Date?=null
}