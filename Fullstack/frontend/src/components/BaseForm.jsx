import { useState } from "react";

export default function BaseForm({ fields, onSubmit, initialValues = {} }) {
  const [values, setValues] = useState(initialValues);

  const handleChange = (name) => (e) =>
    setValues(v => ({ ...v, [name]: e.target.value }));

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(values);
    setValues({}); // limpiar después de guardar
  };

  return (
    <form onSubmit={handleSubmit}>
      {fields.map(f => (
        <div key={f.name}>
          <label>{f.label}</label>
          <input
            type={f.type || "text"}
            value={values[f.name] ?? ""}
            onChange={handleChange(f.name)}
          />
        </div>
      ))}
      <button type="submit">Guardar</button>
    </form>
  );
}
