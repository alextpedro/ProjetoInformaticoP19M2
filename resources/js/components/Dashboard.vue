<script setup>

</script>

<template>
	<!-- Navbar  -->
	<nav class="navbar navbar-expand">
		<div class="container-fluid">
			<!-- Navbar title -->
			<a class="navbar-brand" href="#">Mapview</a>

			<!-- Navbar Items -->
			<div class="collapse navbar-collapse" id="navbarSupportedContent">
				<ul class="navbar-nav me-auto mb-2 mb-lg-0">
					<li class="nav-item">
						<a class="nav-link" href="#">Link 1</a>
					</li>
					<li class="nav-item">
						<a class="nav-link" href="#">Link 2</a>
					</li>
					<li class="nav-item">
						<a class="nav-link" href="#">Link 3</a>
					</li>
					<li class="nav-item">
						<a class="nav-link" href="#">Link 4</a>
					</li>
				</ul>
			</div>
		</div>
	</nav>
	<!-- Content -->
	<div class="container-fluid">
		<div class=" row ">
			<div class="vstack col-3 mx-auto">
				<button class="btn btn-lg btn-primary">Carregar</button>
				<button class="btn btn-lg btn-primary">Estatisticas</button>
				<div class="card" style="width: 18rem;">
					<img src="" class="card-img-top" alt="...">
					<div class="card-body">
						<h5 class="card-title">Card title</h5>
						<p class="card-text">Some quick example text to build on the card title and make up the bulk of
							the card's content.</p>
						<a href="#" class="btn btn-primary">Go somewhere</a>
					</div>
				</div>
			</div>



			<!-- Map -->
			<div class="col">
				<img src="/img/map.jpg" class="img-fluid">
			</div>

		</div>
	</div>
</template>
