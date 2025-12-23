export default function Listado({ personas, onDelete, onEdit }) {
  return (
    <ul>
      {personas.map((p, idx) => (
        <li key={p.id ?? idx}>
          {p.firstName} {p.lastName} - {p.email}
          {p.id && (
            <>
              <button onClick={() => onEdit(p)}>Editar</button>
              <button onClick={() => onDelete(p.id)}>Eliminar</button>
            </>
          )}
        </li>
      ))}
    </ul>
  );
}
