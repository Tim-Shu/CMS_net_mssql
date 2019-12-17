// JavaScript Document
$(function () { $(".icon-menu").click(function () { if ($(".sjdnav").hasClass("sjdnavhide")) { var iphonenav = $(".sjdnav").find("li").length; $(".sjdnav").animate({ "height": (iphonenav * 45) + "px" }, 600); $(".sjdnav").removeClass("sjdnavhide") } else { $(".sjdnav").animate({ "height": "0px" }, 600); $(".sjdnav").addClass("sjdnavhide") } }) });

$(document).ready(function(){
	$(".nul li").hover(function(){
		$(this).find("ul").slideDown("slow");	
	},function(){
		$(this).find("ul").slideUp("fast");	
	});
});
	 var swiper = new Swiper('.swiper-containers', {
        pagination: '.swiper-pagination',
        paginationClickable: true,
		speed:500,
		autoplay: 5000,
		autoplayDisableOnInteraction : false,
		loop: true,
    });
	
	
$(document).ready(function(){
$(".ctnltit1").click(function(){
    $(".ctnls").slideToggle("slow");
  });
});




window.onload = function ()
{
var aLi = document.getElementById("clMenu").getElementsByTagName("li");
var i = 0;
for (i = 0; i < aLi.length; i++)
{
aLi[i].onclick = function ()
{
for (i = 0; i < aLi.length; i++) aLi[i].className = aLi[i].className.replace(/\s?qiu/,"");
this.className += " qiu";
};
}
};
