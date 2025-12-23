import BaseForm from "../components/BaseForm";

export default function FormPageB({ onAdd }) {
  const fields = [
    { name: "firstName", label: "Nombre" },
    { name: "lastName", label: "Apellido" },
    { name: "email", label: "Correo", type: "email" },
    { name: "notes", label: "Notas" },
  ];

  const submit = (values) => {
    onAdd(values); // aquí no llamamos al backend, solo guardamos en state
  };

  return <BaseForm fields={fields} onSubmit={submit} />;
}
