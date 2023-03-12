import { CreateNote } from './components/CreateNote';
import { ErrorMessage } from './components/ErrorMessage';
import { Loader } from './components/Loader';
import { Modal } from './components/Modal';
import { Note } from './components/Note';
import { useProducts } from './hooks/products';

function App() {
  const { notes, loading, error } = useProducts();
  return (
    <div className='container mx-auto max-w-2xl pt-5'>
      {loading && <Loader />}
      {error && <ErrorMessage error={ error } />}
      {notes.map(note => <Note note={note} key={note.id} />)}
      <Modal title="Create note">
        <CreateNote />
      </Modal>
    </div>
  );
}

export default App;
