<!DOCTYPE html>
<!-- saved from url=(0033)# -->
<html class=" supports-js supports-no-touch supports-csstransforms supports-csstransforms3d supports-fontface"><!--<![endif]-->
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

	<!-- Basic page needs ================================================== -->
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	<link rel="shortcut icon" href="" type="image/png">
	<!-- Title and description ================================================== -->
	<title>Art Browser</title>
	<!-- Product meta ================================================== -->
	<meta property="og:type" content="website">
	<meta property="og:title" content="Art Browser">
	<meta property="og:image" content="">
	<meta property="og:image:secure_url" content="">
	<meta property="og:url" content="">
	<meta property="og:site_name" content="ArtBrowser">
	<meta name="twitter:site" content="@">
	<!-- Helpers ================================================== -->
	<meta name="viewport" content="width=device-width,initial-scale=1">
	<meta name="theme-color" content="rgba(45, 203, 112, 1)">

	<!-- CSS ================================================== -->
	<link href="../css/timber.css" rel="stylesheet" type="text/css" media="all">
	<link href="../css/theme.css" rel="stylesheet" type="text/css" media="all">
  
	<script src="../js/jquery.min.js" type="text/javascript"></script>
	<script src="../js/modernizr.min.js" type="text/javascript"></script>
</head>

<body class="template-index">
	<div class="header-bar">
		<div class="wrapper medium-down--hide">
			<div class="large--display-table">
              
			</div>
		</div>
	</div>
	<div class="wrapper large--hide">
		<button type="button" class="mobile-nav-trigger" id="MobileNavTrigger">
			Menu
		</button>
	</div>
	 <ul id="MobileNav" class="mobile-nav large--hide">
		<li class="mobile-nav__link" aria-haspopup="true">
			<a href="Artist.php" class="mobile-nav">Home</a>
		</li>
		<li class="mobile-nav__link" aria-haspopup="true">
			<a href="about.php" class="mobile-nav">About Us</a> 
		</li>
		<li class="mobile-nav__link" aria-haspopup="true">
			<a href="#" class="mobile-nav__sublist-trigger">Artist
				<span class="icon-fallback-text mobile-nav__sublist-expand">
					<span class="icon icon-plus" aria-hidden="true"></span>
				</span>
				<span class="icon-fallback-text mobile-nav__sublist-contract">
					<span class="icon icon-minus" aria-hidden="true"></span>
					<span class="fallback-text">-</span>
				</span>
			</a>
			<ul class="mobile-nav__sublist">  
				<li class="mobile-nav__sublist-link">
					<a href="change-password.php">Change Password</a>
				</li>
				<li class="mobile-nav__sublist-link">
					<a href="../index.php">Signout</a>
				</li>
			</ul>
    
		</li>
	</ul>

	</div><!-- not used -->


	<header class="site-header" role="banner">
		<div class="wrapper">

      <div class="grid--full large--display-table">
        <div class="grid__item large--one-third large--display-table-cell">
          
            <h1 class="site-header__logo large--left" itemscope="" itemtype="http://schema.org/Organization">
          
            
              <a href="index.php" itemprop="url">
                <img src="../images/logo.png" alt="ArtBrowser" itemprop="logo">
              </a>
            
          
            </h1>
          
        </div>
        <div class="grid__item large--two-thirds large--display-table-cell medium-down--hide">
          
<ul class="site-nav" id="AccessibleNav">
  
    
    
    
      <li class="site-nav">
        <a href="Artist.php" class="site-nav__link">Home</a>
      </li>
    
		<li class="site-nav">
        <a href="about.php" class="site-nav__link">About Us</a>
      <li class="site-nav--has-dropdown" aria-haspopup="true">
		<a href="#" class="site-nav__link">
			Artist
			<span class="icon-fallback-text">
				<span class="icon icon-arrow-down" aria-hidden="true"></span>
			</span>
		</a>
		<ul class="site-nav__dropdown">
			<li>
				<a href="change-password.php" class="site-nav__link">Change Password &nbsp;&nbsp;</a>
			</li>
			<li>
				<a href="../index.php" class="site-nav__link">Signout</a>
			</li>
		</ul>
	</li>
    
    
    
      
  
</ul>

        </div>
      </div>

    </div>	</header>

	<main class="wrapper main-content" role="main">
		<div class="grid">
			<div class="grid__item large--one-fifth medium-down--hide">
				   <nav class="sidebar-module">
      <div class="section-header">
        <p class="section-header__title h4">Manage</p>
      </div>
      <ul class="sidebar-module__list">
        
  <li>
    <a href="Artist-view.php" class="">Profile</a>
  </li>

          
  <li class="sidebar-sublist">
    <div class="sidebar-sublist__trigger-wrap">
      <a href="#collections/desktop-pcs" class="sidebar-sublist__has-dropdown ">
        Arts
      </a>
      <button type="button" class="icon-fallback-text sidebar-sublist__expand">
        <span class="icon icon-plus" aria-hidden="true"></span>
        <span class="fallback-text">+</span>
      </button>
      <button type="button" class="icon-fallback-text sidebar-sublist__contract">
        <span class="icon icon-minus" aria-hidden="true"></span>
        <span class="fallback-text">-</span>
      </button>
    </div>
    <ul class="sidebar-sublist__content">
      
        <li>
          <a href="Arts.php">Add Item</a>
        </li>
      
        <li>
          <a href="#">Update Item</a>
        </li>
      
    </ul>
  </li>


        
          
  <li class="sidebar-sublist">
    <div class="sidebar-sublist__trigger-wrap">
      <a href="#" class="sidebar-sublist__has-dropdown ">
        Announcements
      </a>
      <button type="button" class="icon-fallback-text sidebar-sublist__expand">
        <span class="icon icon-plus" aria-hidden="true"></span>
        <span class="fallback-text">+</span>
      </button>
      <button type="button" class="icon-fallback-text sidebar-sublist__contract">
        <span class="icon icon-minus" aria-hidden="true"></span>
        <span class="fallback-text">-</span>
      </button>
    </div>
    <ul class="sidebar-sublist__content">
      
        <li>
          <a href="Announcement.php">Add Announcement</a>
        </li>
      
        <li>
          <a href="#">Update Announcement</a>
        </li>
      
    </ul>
  </li>
    
<li>
    <a href="Order.php" class="">Orders</a>
  </li>	
  <li>
    <a href="#collections/Gallery3" class="">Account</a>
  </li>
  
      </ul>
    </nav>
  
  <nav class="sidebar-module">
    <div class="section-header">
      <p class="section-header__title h4">Help</p>
    </div>
    <ul class="sidebar-module__list">
        
  <li>
    <a href="#" class="">Get Started</a>
  </li>
  <li>
    <a href="#" class="">FAQ</a>
  </li>
	</ul>
  </nav>

			</div>
			<div class="grid__item large--four-fifths">
				<div class="section-header section-header--large">
					<h2 class="section-header__title--left section-header__title h4">
						Artist Profile
					</h2>
					<div class="section-header__link--right medium-down--hide">
						<a href="Profile.php" title="Browse our Gallery3 collection">Edit Profile</a>
					</div>
				</div>
				<div class="grid-uniform grid-link__container">
					<form name="myform" method="post" enctype="multipart/form-data" onsubmit="return validateForm()">
						<style>
							td {
								border:0px;
								padding:0px;
							}
						</style>
						
							<style>
								th, td, tr {
									text-align: left;
									padding: 0px;
									border: 0px solid #f0f0f0;
									font-size: 14px;
								}
							</style>
					<div class="grid-uniform grid-link__container">
						<!----------------------------------------- start here content layout ------------------------------>
						<div class="cover">
							<img src="../images/picBanner.jpg" height="250" width="750">
						</div>
						
						<div class="section-header section-header--large" style="margin-top:-10px;display:table;">
							<div class="section-header__title--left section-header__title" style="width:130px;">
								<div class="profile" style="width:130px;">
								<img src="../images/user_pic.jpg" style="width:130px;height:130px;margin-top:-35px;">
								<!--<center style="margin:-10px;line-height:1"><b>Mrs. safrine</b><br/>admin@gmail.com<br/>26 years old</center>-->
								</div>
							</div>
							<div class="section-header__title--right" style="float:left;text-align: left;padding:5px;">
								<h3 style="margin:0px;line-height:1.3">Mrs. Safrine</h3>
								<h3 style="margin:0px;line-height:1.3">27</h3>
								<h3 style="margin:0px;line-height:1.3">Noida</h3>
							</div>
						</div>
						<div class="profile-lay" style="margin-top:-20px;">
							<h3 style="margin:0px;line-height:1.3">Safrine's Statement</h3>
							<p style="margin:0px;line-height:1.3"><b>Expertise:</b>&nbsp;&nbsp;<a>Sculptor</a></p>
							<p style="margin:0px;line-height:1.3"><b>Education:</b>&nbsp;&nbsp;<a>Noida College of Art</a></p>
							<p style="text-align:justify;text-justify:inter-word;line-height:1.3">
								<b>Artist's Statement:</b>In my final year at 
								stackoverflow.com/.../bootstrap-alignment-of-button-and-pagination
								Nov 4, 2013 - I am using Twitter Bootstrap 3 to build my new website. I want to place a button on ... 
								The alternative is to simply extend the .pagination class</p>
						
							<!----------------------------------------- end here content layout ------------------------------>
						</div>				
							<small class="view-more">
								<a href="Artist.php" title="Browse our Gallery3 collection">View all Items</a>
							</small>
						<div class="section-header section-header--large">
						  <h2 class="section-header__title--left section-header__title h4">
							  Arts
						  </h2>
						  <div class="section-header__link--right medium-down--hide">
							<a href="Artist.php" title="Browse our Gallery3 collection">View all Items</a>
						  </div>
						</div>
						<!---- ---->
						<div class="grid-uniform grid-link__container">
							<div class="grid__item medium-down--one-half large--one-quarter" style="margin-left:2%;margin-right:2%;width: 20%;">
							  <a href="#products/1tb-intenso-portable-external-hard-drive" class="grid-link">
								<p class="grid-link__title" style="margin-bottom: 0px;">Art 1</p>
								<span class="grid-link__image grid-link__image--product" style="height: 170px;">
								  <span class="grid-link__image-centered">
									<img src="../images/Gallery1.jpg" alt="Art 1">
								  </span>
								</span>
								<p class="grid-link__meta">
								  <strong>$45.99</strong>
								</p>
							  </a>
							</div>
							
							<div class="grid__item medium-down--one-half large--one-quarter" style="margin-left:2%;margin-right:2%;width: 20%;">
							  <a href="#products/1tb-intenso-portable-external-hard-drive" class="grid-link">
								<p class="grid-link__title" style="margin-bottom: 0px;">Art 1</p>
								<span class="grid-link__image grid-link__image--product" style="height: 170px;">
								  <span class="grid-link__image-centered">
									<img src="../images/Gallery1.jpg" alt="Art 1">
								  </span>
								</span>
								<p class="grid-link__meta">
								  <strong>$45.99</strong>
								</p>
							  </a>
							</div>
							
							<div class="grid__item medium-down--one-half large--one-quarter" style="margin-left:2%;margin-right:2%;width: 20%;">
							  <a href="#products/1tb-intenso-portable-external-hard-drive" class="grid-link">
								<p class="grid-link__title" style="margin-bottom: 0px;">Art 1</p>
								<span class="grid-link__image grid-link__image--product" style="height: 170px;">
								  <span class="grid-link__image-centered">
									<img src="../images/Gallery1.jpg" alt="Art 1">
								  </span>
								</span>
								<p class="grid-link__meta">
								  <strong>$45.99</strong>
								</p>
							  </a>
							</div>
							
							<div class="grid__item medium-down--one-half large--one-quarter" style="margin-left:2%;margin-right:2%;width: 20%;">
							  <a href="#products/1tb-intenso-portable-external-hard-drive" class="grid-link">
								<p class="grid-link__title" style="margin-bottom: 0px;">Art 1</p>
								<span class="grid-link__image grid-link__image--product" style="height: 170px;">
								  <span class="grid-link__image-centered">
									<img src="../images/Gallery1.jpg" alt="Art 1">
								  </span>
								</span>
								<p class="grid-link__meta">
								  <strong>$45.99</strong>
								</p>
							  </a>
							</div>
							
							<div class="grid__item medium-down--one-half large--one-quarter" style="margin-left:2%;margin-right:2%;width: 20%;">
							  <a href="#products/1tb-intenso-portable-external-hard-drive" class="grid-link">
								<p class="grid-link__title" style="margin-bottom: 0px;">Art 1</p>
								<span class="grid-link__image grid-link__image--product" style="height: 170px;">
								  <span class="grid-link__image-centered">
									<img src="../images/Gallery1.jpg" alt="Art 1">
								  </span>
								</span>
								<p class="grid-link__meta">
								  <strong>$45.99</strong>
								</p>
							  </a>
							</div>
							
							<div class="grid__item medium-down--one-half large--one-quarter" style="margin-left:2%;margin-right:2%;width: 20%;">
							  <a href="#products/1tb-intenso-portable-external-hard-drive" class="grid-link">
								<p class="grid-link__title" style="margin-bottom: 0px;">Art 1</p>
								<span class="grid-link__image grid-link__image--product" style="height: 170px;">
								  <span class="grid-link__image-centered">
									<img src="../images/Gallery1.jpg" alt="Art 1">
								  </span>
								</span>
								<p class="grid-link__meta">
								  <strong>$45.99</strong>
								</p>
							  </a>
							</div>
							
							<div class="grid__item medium-down--one-half large--one-quarter" style="margin-left:2%;margin-right:2%;width: 20%;">
							  <a href="#products/1tb-intenso-portable-external-hard-drive" class="grid-link">
								<p class="grid-link__title" style="margin-bottom: 0px;">Art 1</p>
								<span class="grid-link__image grid-link__image--product" style="height: 170px;">
								  <span class="grid-link__image-centered">
									<img src="../images/Gallery1.jpg" alt="Art 1">
								  </span>
								</span>
								<p class="grid-link__meta">
								  <strong>$45.99</strong>
								</p>
							  </a>
							</div>
							
							<div class="grid__item medium-down--one-half large--one-quarter" style="margin-left:2%;margin-right:2%;width: 20%;">
							  <a href="#products/1tb-intenso-portable-external-hard-drive" class="grid-link">
								<p class="grid-link__title" style="margin-bottom: 0px;">Art 1</p>
								<span class="grid-link__image grid-link__image--product" style="height: 170px;">
								  <span class="grid-link__image-centered">
									<img src="../images/Gallery1.jpg" alt="Art 1">
								  </span>
								</span>
								<p class="grid-link__meta">
								  <strong>$45.99</strong>
								</p>
							  </a>
							</div>
							
						</div>
						<!--<div class="section-header section-header--large">
							<div class="section-header__title--left section-header__title" style="width:130px;">
								
							</div>
							<div class="section-header__title--right">
								
							</div>
						</div>-->
						<div class="section-header">
							<div class="section-header__title--left section-header__title" style="width:38%">
								<span class="grid-link__image-centered" >
									<img src="../images/pic2.jpg" alt="Art 1" style="width:290px;height:200px;">
								</span>
							</div>
							<div class="section-header__link--right" style="float:left;text-align: left;padding-left:5px;width:100%">
								<p style="margin:0px;line-height:1.3"><b>Location:</b><a>Rijk Museum, Amsterdam</a></p>
								<p style="margin:0px;line-height:1.3"><b>Dates:</b><a>18/01/15 - 19/03/15</a></p>
								<p style="margin:0px;line-height:1.3;text-align:justify;text-justify:inter-word;"><b>Statement:</b>In this exhibition I worked with several other up and coming artists. We decided to work with the white cude surroundings by using bold colours to attaract the attention of the audience. The exhibition was advertised in servral local newspapers.
							</div>
						</div>

						<small class="view-more">
						  <a href="#collections/all" title="Browse our Gallery3 collection">View all Items</a>
						</small>
						<!----------->
					</div>
			  
				</div>
			</main>

		<footer class="site-footer small--text-center" role="contentinfo">
			<footer class="site-footer small--text-center" role="contentinfo">

    <div class="wrapper">

      <div class="grid-uniform ">

        
        
        
        
        
        

        

        
          <div class="grid__item large--one-quarter medium--one-half">
            <h4>Quick Links</h4>
            <ul class="site-footer__links">
              
                <li><a href="#pages/contact-us">Contact Us</a></li>
              
                <li><a href="#pages/about-us">Private Policy</a></li>
              
                <li><a href="#pages/about-us">FAQ</a></li>
              
                <li><a href="#pages/about-us">About Us</a></li>
              
            </ul>
            
          </div>
        

        
          <div class="grid__item large--one-quarter medium--one-half">
            <h4>Get Connected</h4>
              
              <ul class="inline-list social-icons">
                
                  <li>
                    <a class="icon-fallback-text" href="https://twitter.com/" title="ArtBrowser on Twitter">
                      <span class="icon icon-twitter" aria-hidden="true"></span>
                      <span class="fallback-text">Twitter</span>
                    </a>
                  </li>
                
                
                  <li>
                    <a class="icon-fallback-text" href="https://www.facebook.com/" title="ArtBrowser on Facebook">
                      <span class="icon icon-facebook" aria-hidden="true"></span>
                      <span class="fallback-text">Facebook</span>
                    </a>
                  </li>
                
                  <li>
                    <a class="icon-fallback-text" href="#" title="ArtBrowser on RSS">
                      <span class="icon icon-rss" aria-hidden="true"></span>
                      <span class="fallback-text">RSS</span>
                    </a>
                  </li>
                
              </ul>
			  <a id="appStoreLink" href="#" target="_blank" title="Download on the App Store"><img src="//d3t95n9c6zzriw.cloudfront.net/covers/landing/mobile/cta_app_store.png" alt="Download on the App Store" data-pin-nopin="true"></a>
          </div>
        

        
          <div class="grid__item large--one-quarter medium--one-half">
            <h4>Contact Us</h4>
            <div class="rte">44-800-123-4567<br>
<a href="##">support@example.com</a><br>
36 St Andrew Square.<br>
Edinburgh, United Kingdom<br></div>
          </div>
        

        
          <div class="grid__item large--one-quarter medium--one-half">
            <h4>Newsletter</h4>
            <p>Sign up for promotions</p>
            
			<form action="##" method="post" id="mc-embedded-subscribe-form" name="mc-embedded-subscribe-form" target="_blank" class="input-group">
			  <input type="email" value="" placeholder="" name="EMAIL" id="mail" class="input-group-field" autocorrect="off" autocapitalize="off">
			  <span class="input-group-btn">
				<input type="submit" class="btn" name="subscribe" id="subscribe" value="Subscribe">
			  </span>
			</form>

          </div>
        
      </div>

      <hr>

      <div class="grid">
        <div class="grid__item large--one-half large--text-left medium-down--text-center">
          <p class="site-footer__links">Copyright © 2015, Art Browser. </p>
        </div>
        
          <div class="grid__item large--one-half large--text-right medium-down--text-center">
            <ul class="inline-list payment-icons">
              
                
                <li>
                  <span class="icon-fallback-text">
                    <span class="icon icon-master" aria-hidden="true"></span>
                    <span class="fallback-text">master</span>
                  </span>
                </li>
              
                <li>
                  <span class="icon-fallback-text">
                    <span class="icon icon-visa" aria-hidden="true"></span>
                    <span class="fallback-text">visa</span>
                  </span>
                </li>
              
            </ul>
          </div>
        
      </div>

    </div>

  </footer>		</footer>
		
		<script src="../js/fastclick.js" type="text/javascript"></script>
		<script src="../js/timber.js" type="text/javascript"></script>
		<script src="../js/theme.js" type="text/javascript"></script>

	</body>
</html>