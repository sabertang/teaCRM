﻿//*主项目头部js
//*作者：唐有炜
//*时间：2014年07月28日
$(document).ready(function() {
    //显示欢迎
    sayHello();
    //显示更多
    showMore();
});

$(function () {
    //加载菜单
    load_menu();
    //菜单切换
    changeTab();
});

//显示更多
function showMore() {
    var d_more;
    $("#head-nav-more").click(function() {
            d_more = dialog({
                content: ' <ul class="head-nav" style="background:#1173ee;margin:10px 10px -10px 10px;"><li id="head-nav-sale"><a href="/Apps/Sale/">销售</a></li><li id="head-nav-product"><a href="/Apps/Product/">产品</a></li><li id="head-nav-service"><a href="/Apps/Service/">服务</a></li></ul>',
                quickClose: true // 点击空白处快速关闭
            });
            d_more.show(this);
        })
        //.mouseout(function() {
        // setTimeout(function() {
        //    d_more.close().remove();
        //}, 10000);
        //    })
        ;
}


//欢迎语
function sayHello() {
    var now = new Date(), hour = now.getHours();
    var welcome = "";
    if (hour < 6) {
        welcome = "凌晨好！";
    } else if (hour < 9) {
        welcome = "早上好！";
    } else if (hour < 12) {
        welcome = "上午好！";
    } else if (hour < 14) {
        welcome = "中午好！";
    } else if (hour < 17) {
        welcome = "下午好！";
    } else if (hour < 19) {
        welcome = "傍晚好！";
    } else if (hour < 22) {
        welcome = "晚上好！";
    } else {
        welcome = "夜里好！";
    }
    $("#sayHello").html(welcome);
}

//加载菜单
function load_menu() {
    alert("菜单加载完毕！");
}


//菜单切换
function changeTab() {
    var url = location.href;
    $(".head-nav li").removeClass("selected");
    //alert(url);
    if (url.indexOf("/Apps/CRM/") > 0) {
        //alert("customer");
        $("#head-nav-customer").addClass("selected");
        $("#menu-customer").removeClass("hide").removeClass("hide").show();
        //二级分类选中===================================
        $(".nav2 li").removeClass("selected");
          if (url.indexOf("Index") > 0) {
              $("#all").addClass("selected");
          } else if (url.indexOf("Trash") > 0) {
              $("#trash").addClass("selected");
          } else if (url.indexOf("Pub") > 0) {
              $("#pub").addClass("selected");
          } else if (url.indexOf("Contact") > 0) {
              $("#contact").addClass("selected");
          } else {
              $("#all").addClass("selected");  
          }
    } else if (url.indexOf("/Apps/Sale/") > 0) {
        $("#head-nav-more").addClass("selected");
        $("#menu-sale").removeClass("hide").show();
    }
    else if ( url.indexOf("/Apps/Product/") > 0) {
        $("#head-nav-more").addClass("selected");
        $("#menu-product").removeClass("hide").show();
    }
    else if (url.indexOf("/Apps/Service/")>0) {
        $("#head-nav-more").addClass("selected");
        $("#menu-service").removeClass("hide").show();
    }
    else if (url.indexOf("/Apps/Settings/") > 0) {
        //alert("Department");
        $("#head-nav-settings").addClass("selected");
        $("#menu-settings").removeClass("hide").removeClass("hide").show();
        //
    }  else if (url.indexOf("/Apps/") > 0) {
        //alert("index");
        $("#head-nav-app").addClass("selected");
        $("#menu-app").removeClass("hide").show();
    } else if (url.indexOf("/Desktop/") > 0) {
        $("#head-nav-desktop").addClass("selected");
        $("#menu-desktop").removeClass("hide").show();
    } else {
        $("#head-nav-desktop").addClass("selected");
        $("#menu-desktop").removeClass("hide").show();
    }
}