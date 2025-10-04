import React, { useState, useEffect } from 'react'
import './App.css'
import HelloWorld from './hello'

function App() {
	// const [count, setCount] = useState(0);	// getter & setter

	// useEffect( () => {
	// 	setCount(3);
	// }, []);

	// useEffect( () => {
	// 	console.log(count)
	// }, [count]);

	// const increment = () => {
	// 	setCount(count + 1);

	// 	// setCount(oldCount => {
	// 	// 	return oldCount + 1;
	// 	// })
	// }

	const [pokemons, setPokemons] = useState();

	const loadPokemons = () => {
		fetch("https://pokeapi.co/api/v2/pokemon?limit=60")
			.then((response) => response.json())
			.then((_pokemons) => setPokemons(_pokemons.results));
	}

	const PokemonCard = (props) => {
		return (
			<div>
				<h1>{props.pokemon.name}</h1>
				<p>{props.pokemon.url}</p>
				<hr/>
			</div>
		)
	}

	return (
	<>
		<h2>A</h2>

		<h1>
			<div>
				{pokemons.map((pokemon) => (
					<PokemonCard pokemon={pokemon}/>
				))}
			</div>
		</h1>

		<button className="btn" onClick={loadPokemons}>Load Pokemons</button>
	</>
  );
}

export default App
