import BaseForm from "../components/BaseForm";

export default function FormPageA({ onAdd }) {
  const fields = [
    { name: "firstName", label: "Nombre" },
    { name: "lastName", label: "Apellido" },
    { name: "email", label: "Correo", type: "email" },
    { name: "document", label: "Documento" },
  ];

  const submit = async (values) => {
    try {
      const res = await fetch("http://localhost:5018/api/persons", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(values),
      });
      if (res.ok) {
        const created = await res.json();
        onAdd(created);
      } else {
        alert("Error al crear persona");
      }
    } catch {
      alert("No se pudo conectar al backend");
    }
  };

  return <BaseForm fields={fields} onSubmit={submit} />;
}
