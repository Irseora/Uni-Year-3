let pokemons = [];

// type colors
const colors = {
	normal: "#A8A77A",
	fire: "#EE8130",
	water: "#6390F0",
	electric: "#F7D02C",
	grass: "#7AC74C",
	ice: "#96D9D6",
	fighting: "#C22E28",
	poison: "#A33EA1",
	ground: "#E2BF65",
	flying: "#A98FF3",
	psychic: "#F95587",
	bug: "#A6B91A",
	rock: "#B6A136",
	ghost: "#735797",
	dragon: "#6F35FC",
	dark: "#705746",
	steel: "#B7B7CE",
	fairy: "#D685AD",
};

// grab all pokemons
async function loadPokemons() {
	await fetch("https://pokeapi.co/api/v2/pokemon?limit=60")
		.then((response) => response.json())
		.then((json) => {
			pokemons = json.results;
		});

	for (let pokemon of pokemons) {
		// grab data from current pokemons url
		await fetch(pokemon.url)
			.then((response) => response.json())
			.then((json) => {
				sprite = json.sprites.front_default;
				types = json.types;
			});

		// build color and type string
		if (types.length == 1) {
			cardColor = colors[types[0].type.name];
			typeString = types[0].type.name;
		} else {
			color1 = colors[types[0].type.name];
			color2 = colors[types[1].type.name];
			cardColor = `linear-gradient(90deg, ${color1} 0%, ${color2} 100%)`;
			typeString = types[0].type.name + " " + types[1].type.name;
		}

		// build card
		let pokemonCard = `
			<div class="card" style="background: ${cardColor}">
				<img src="${sprite}">
	
				<div class="text-container">
					<h3>${pokemon.name}</h3>
					<p>${typeString}</p>
				</div>
			</div>
		`;

		document.getElementById("cards-container").innerHTML += pokemonCard;
	}
}

loadPokemons();
