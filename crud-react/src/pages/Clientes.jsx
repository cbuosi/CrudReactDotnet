import { useEffect, useState } from "react"
import api from "../services/api"

export default function Clientes() {
  const [clientes, setClientes] = useState([])
  const [filtro, setFiltro] = useState("")
  const [erro, setErro] = useState(null)
  const [loading, setLoading] = useState(true)
  const [cargos, setCargos] = useState([])

  const [novoCliente, setNovoCliente] = useState({
    nome: "",
    dataNascimento: "",
    endereco: "",
    uf: "SP",
    cargoId: 1
  })

  function editarCliente(cliente) {
    setNovoCliente({
      id: cliente.id,
      nome: cliente.nome,
      dataNascimento: cliente.dataNascimento?.substring(0,10),
      endereco: cliente.endereco,
      uf: cliente.uf,
      cargoId: cliente.cargoId
    })
  }

  async function carregarCargos() {
    const res = await api.get("/cargos")
    setCargos(res.data)
  }

  function alterarCampo(e) {
    const { name, value } = e.target

    setNovoCliente({
      ...novoCliente,
      [name]: value
    })
  }  

  async function salvarCliente(e) 
  {
    e.preventDefault()

    try 
    {

      if (novoCliente.id)
      await api.put(`/clientes/${novoCliente.id}`, novoCliente)
      else
      await api.post("/clientes", novoCliente)

      setNovoCliente({
      nome:"",
      dataNascimento:"",
      endereco:"",
      uf:"SP",
      cargoId:1
      })

      carregarClientes()

    } 
    catch (e) 
    {
      alert("Erro: " + (e?.response?.data || e.message))
    }
  }

  async function excluirCliente(id) 
  {

    if (!confirm("Deseja realmente excluir?")) return

    try 
    {
      await api.delete(`/clientes/${id}`)
      carregarClientes()   // recarrega a lista
    } catch (e) 
    {
      alert("Erro ao excluir: " + (e?.response?.data || e.message))
    }
  }

  async function carregarClientes() 
  {
    try {
      const res = await api.get("/clientes")
      setClientes(res.data)
    } catch (e) {
      setErro(e?.response?.data || e.message)
    } finally {
      setLoading(false)
    }
  }

  useEffect(() => {
    carregarClientes()
    carregarCargos()
  }, [])

  const clientesFiltrados = clientes.filter(c =>
    c.nome.toLowerCase().includes(filtro.toLowerCase())
  )

  if (loading) return <p>Carregando...</p>

  if (erro) return <p>Erro: {erro}</p>

  return (
    <div style={{ padding: 20 }}>
      <h2>Clientes</h2>

    <input
      type="text"
      placeholder="Buscar por nome"
      value={filtro}
      onChange={(e) => setFiltro(e.target.value)} />      

  <h3>Novo Cliente</h3>

  <form onSubmit={salvarCliente}>

  <input
    name="nome"
    placeholder="Nome"
    value={novoCliente.nome}
    onChange={alterarCampo}
  />

  <br/>

  <input
    type="date"
    name="dataNascimento"
    value={novoCliente.dataNascimento}
    onChange={alterarCampo}
  />

  <br/>

  <input
    name="endereco"
    placeholder="Endereço"
    value={novoCliente.endereco}
    onChange={alterarCampo}
  />

  <br/>

  <select
    name="uf"
    value={novoCliente.uf}
    onChange={alterarCampo}
  >
    <option value="SP">SP</option>
    <option value="RJ">RJ</option>
    <option value="MG">MG</option>
  </select>

  <br/>

  <input
    type="number"
    name="cargoId"
    value={novoCliente.cargoId}
    onChange={alterarCampo}
  />

  <br/><br/>

  <button type="submit">
    Salvar
  </button>

  </form>

      <table border="1" cellPadding="6">
        <thead>
          <tr>
            <th>Ações</th>
            <th>ID</th>
            <th>Nome</th>
            <th>UF</th>
            <th>CargoId</th>
          </tr>
        </thead>
        <tbody>
          {clientesFiltrados.map(c => (
            <tr key={c.id}>
              <td>
                <button onClick={() => editarCliente(c)}>
                  Editar
                </button>
                <button onClick={() => excluirCliente(c.id)}>
                  Excluir
                </button>
              </td>              
              <td>{c.id}</td>
              <td>{c.nome}</td>
              <td>{c.uf}</td>
              
              <td>
                <select name="cargoId" value={novoCliente.cargoId} onChange={alterarCampo}>
                  {cargos.map(c => (
                    <option key={c.id} value={c.id}>
                      {c.nome}
                    </option>
                  ))}
                </select>
              </td>
              
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}