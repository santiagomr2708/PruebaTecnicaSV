import { BrowserRouter, Routes, Route, Link } from "react-router-dom";
import { useState } from "react";
import FormPageA from "./pages/FormPageA";
import FormPageB from "./pages/FormPageB";
import Listado from "./components/Listado";
import BaseForm from "./components/BaseForm";


function App() {
  const [personasA, setPersonasA] = useState([]);
  const [personasB, setPersonasB] = useState([]);
  const [search, setSearch] = useState("");
  const [editing, setEditing] = useState(null);


  const consolidado = [...personasA, ...personasB];

  const filtrado = consolidado.filter(p =>
    (`${p.firstName} ${p.lastName}`).toLowerCase().includes(search.toLowerCase())
  );

  const handleDelete = async (id) => {
    try {
      const res = await fetch(`http://localhost:5018/api/persons/${id}`, {
        method: "DELETE",
      });
      if (res.ok) {
        setPersonasA(prev => prev.filter(p => p.id !== id));
      } else {
        alert("Error al eliminar persona");
      }
    } catch {
      alert("No se pudo conectar al backend");
    }
  };

  const handleEdit = (person) => setEditing(person);

  const handleUpdate = async (values) => {
  try {
    const res = await fetch(`http://localhost:5018/api/persons/${editing.id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(values),
    });
    if (res.ok) {
      setPersonasA(prev =>
        prev.map(p => (p.id === editing.id ? { ...p, ...values } : p))
      );
      setEditing(null);
    } else {
      alert("Error al actualizar persona");
    }
  } catch {
    alert("No se pudo conectar al backend");
  }
};


  return (
    <BrowserRouter>
      <nav>
        <Link to="/">Listado</Link> | <Link to="/form-a">Formulario A</Link> | <Link to="/form-b">Formulario B</Link>
      </nav>
      <input
        placeholder="Buscar por nombre"
        value={search}
        onChange={e => setSearch(e.target.value)}
      />
      <Routes>
        <Route path="/" element={<Listado personas={filtrado} onDelete={handleDelete} onEdit={handleEdit} />} />
        <Route path="/form-a" element={<FormPageA onAdd={p => setPersonasA(prev => [...prev, p])} />} />
        <Route path="/form-b" element={<FormPageB onAdd={p => setPersonasB(prev => [...prev, p])} />} />
      </Routes>

      {/* Formulario de edición aparece solo si hay persona seleccionada */}
      {editing && ( 
        <BaseForm 
          key={editing.id} // fuerza que se reinicie al cambiar de persona
          fields={[ 
            { name: "firstName", label: "Nombre" }, 
            { name: "lastName", label: "Apellido" }, 
            { name: "email", label: "Correo", type: "email" }, 
          ]} 
          initialValues={editing} 
          onSubmit={handleUpdate} 
        /> 
      )}

    </BrowserRouter>
  );
}

export default App;
