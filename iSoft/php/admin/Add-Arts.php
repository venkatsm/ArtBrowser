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
			<a href="index.php" class="mobile-nav">Home</a>
		</li>
		<li class="mobile-nav__link" aria-haspopup="true">
			<a href="about.php" class="mobile-nav">About Us</a> 
		</li>
		<li class="mobile-nav__link" aria-haspopup="true">
			<a href="#" class="mobile-nav__sublist-trigger">Administrator
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
					<a href="Admin.php" class="site-nav__link">Home</a>
				</li>

				<li class="site-nav">
					<a href="about.php" class="site-nav__link">About Us</a>
				</li>

				<li class="site-nav--has-dropdown" aria-haspopup="true">
					<a href="#" class="site-nav__link">
						Administrator
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
			<p class="section-header__title h4">Admin Panel</p>
		  </div>
			<ul class="sidebar-module__list">
        
		  <li>
			<a href="Profile.php" class="">Profile</a>
		  </li>

  <li class="sidebar-sublist">
    <div class="sidebar-sublist__trigger-wrap">
      <a href="#collections/desktop-pcs" class="sidebar-sublist__has-dropdown ">
        Users
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
          <a href="User-Artist.php">Artist</a>
        </li>
      
        <li>
          <a href="User-Gallery.php">Gallery</a>
        </li>
      
    </ul>
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
  
  <li class="sidebar-sublist">
    <div class="sidebar-sublist__trigger-wrap">
      <a href="#" class="sidebar-sublist__has-dropdown ">
        My Actions
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
          <a href="My-action-User.php">Users</a>
        </li>
      
		<li>
          <a href="My-Action-Arts.php">Arts</a>
        </li>
        <li>
          <a href="My-Action-Announcements.php">Announcements</a>
        </li>
      
    </ul>
  </li>
  
  <li>
    <a href="Search.php" class="">Search</a>
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
						Add Arts
					</h2>
					<!--<div class="section-header__link--right medium-down--hide">
						<a href="#collections/all" title="Browse our Gallery3 collection">View all Items</a>
					</div>-->
				</div>
				<div class="grid-uniform grid-link__container">
					<form name="myform" method="post" enctype="multipart/form-data" onsubmit="return validateForm()">
						<style>
							td {
								border:0px;
								padding:0px;
							}
						</style>
						<table>
							<tr>
								<td>
									Title<input type="text" name="tname">
								</td>
							</tr>
							<tr>
								<td>
									Category<input type="text" name="cname">
								</td>
							</tr>
							<tr>
								<td>
									Subcategory<input type="text" name="sname">
								</td>
							</tr>
							<tr>
								<td>Image:<input type="file" name="imgfile"></td>
							</tr>
							<tr>
								<td>
									Subject<input type="text" name="subname">
								</td>
							</tr>
							<tr>
								<td>
									Price<input type="text" name="price">
								</td>
							</tr>
							
							<tr>
								<td>
									Location<select name="lock">
									<option></option>
									<option>India</option>
									<option>USA</option>
									<option>UAE</option>
									</select>
								</td>
							</tr>
							<tr>
								<td>
									Size<input type="text" name="size">
								</td>
							</tr>
							<tr>
								<td>
									Medium<input type="text" name="medium">
								</td>
							</tr>
							<tr>
								<td>
									Date<br/><input type="date" name="date"/>
								</td>
							</tr>
							<tr>
								<td><br/>
									Tags<input type="text" name="tag">
								</td>
							</tr>
							<tr>
								<td>
									Statement<textarea rows="4" cols="50"> </textarea>
								</td>
							</tr>
							<tr>
								<td><input type="submit" value="Add Art"></td>
							</tr>
						</table>
					</form>
				</div>
				<script>
					function validateForm() {
						
						var x = document.forms["myform"]["tname"].value;
						var y = document.forms["myform"]["subname"].value;
						var z = document.forms["myform"]["price"].value;
						var b = document.forms["myform"]["lock"].value;
						var c = document.forms["myform"]["size"].value;
						var d = document.forms["myform"]["medium"].value;
						var a = document.forms["myform"]["date"].value;
						
						if (x == null || x == "") {
							alert("Title must be filled out");
							return false;
						}
						
						if (y == null || y == "") {
							alert(" Subject is required");
							return false;
						}
						if (z == null || z == "") {
							alert("price must be filled out");
							return false;
						}
						
						if (b == null || b == "") {
							alert("Location is required");
							return false;
						}
						if (c == null || c == "") {
							alert("Please tell the size of article");
							return false;
						}
						if (d == null || d == "") {
							alert("Please tell us about medium");
							return false;
						}
						if (a == null || a == "") {
							alert("Date is required");
							return false;
						}
					}
					</script>
					<div class="grid__item medium-down--one-half large--one-quarter">
						<a href="#products/1tb-intenso-portable-external-hard-drive" class="grid-link">
							<span class="grid-link__image grid-link__image--product" style="height: 208px;">
								<span class="spr-starrating spr-badge-starrating">
									<i class="spr-icon spr-icon-star" style=""></i>
									<i class="spr-icon spr-icon-star" style=""></i>
									<i class="spr-icon spr-icon-star" style=""></i>
									<i class="spr-icon spr-icon-star" style=""></i>
									<i class="spr-icon spr-icon-star" style=""></i>
								</span>
  
							</span>
						</a>
					</div>
					<div class="grid__item medium-down--one-half large--one-quarter">
						<a href="#products/acer-i3-8gb-750gb-win-8" class="grid-link">
							<span class="grid-link__image grid-link__image--product" style="height: 208px;">
								<br><span class="spr-badge" id="spr_badge_405353036" data-rating="4.0">
  
								<span class="spr-starrating spr-badge-starrating">
									<i class="spr-icon spr-icon-star" style=""></i>
									<i class="spr-icon spr-icon-star" style=""></i>
									<i class="spr-icon spr-icon-star" style=""></i>
									<i class="spr-icon spr-icon-star" style=""></i>
									<i class="spr-icon spr-icon-star-empty" style=""></i>
								</span>
							</span>
						</a>
					</div>
					<br>
					<span class="spr-badge" id="spr_badge_405353076" data-rating="0.0">
  
						<span class="spr-starrating spr-badge-starrating">
							<i class="spr-icon spr-icon-star-empty" style=""></i>
							<i class="spr-icon spr-icon-star-empty" style=""></i>
							<i class="spr-icon spr-icon-star-empty" style=""></i>
							<i class="spr-icon spr-icon-star-empty" style=""></i>
							<i class="spr-icon spr-icon-star-empty" style=""></i>
						</span>
					</span>
			</div>
			<small class="view-more">
				<a href="#collections/all" title="Browse our Gallery3 collection">View all Items</a>
			</small>

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

  </footer>	</footer>
	<script src="../js/fastclick.js" type="text/javascript"></script>
	<script src="../js/timber.js" type="text/javascript"></script>
	<script src="../js/theme.js" type="text/javascript"></script>
</body>
</html>