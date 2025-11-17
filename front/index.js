// Atualiza os cards da dashboard com dados reais da API
const apiUrl = "http://localhost:5116/api";

async function fetchCount(endpoint) {
	try {
		const res = await fetch(`${apiUrl}/${endpoint}`);
		const data = await res.json();
		return data.length;
	} catch (err) {
		console.error("Erro ao buscar", endpoint, err);
		return "--";
	}
}

async function loadDashboard() {
	const itens = await fetchCount("Itens");
	const usuarios = await fetchCount("Usuarios");
	const tipos = await fetchCount("Tipos");
	const requisicoes = await fetchCount("Requisicoes");

	document.querySelector("#card-itens p").textContent = itens;
	document.querySelector("#card-usuarios p").textContent = usuarios;
	document.querySelector("#card-tipos p").textContent = tipos;
	document.querySelector("#card-requisicoes p").textContent = requisicoes;
}

loadDashboard();
