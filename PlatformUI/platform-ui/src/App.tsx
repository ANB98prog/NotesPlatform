import { useState } from 'react';
import { CreateNote } from './components/CreateNote';
import { ErrorMessage } from './components/ErrorMessage';
import { Loader } from './components/Loader';
import { Modal } from './components/Modal';
import { Note } from './components/Note';
import { INote } from './data/models';
import { useNotes } from './hooks/notes';

function App() {
  const { notes, loading, error, addNote } = useNotes();
  const [modal, setModal] = useState(false);

  const onNoteCreated = (note: INote) => {
    setModal(false);
    addNote(note);
  }

  return (
    <div className='container mx-auto max-w-2xl pt-5'>
      {loading && <Loader />}
      {error && <ErrorMessage error={ error } />}
      {notes.map(note => <Note note={note} key={note.id} />)}
      {modal && <Modal onClose={() => setModal(false)} title="Create note">
        <CreateNote onCreate={onNoteCreated} />
      </Modal>}

      <button 
        className='fixed bottom-5 right-5 rounded-full bg-blue-600 text-white text-2xl px-4 py-2'
        onClick={() => setModal(true)}>+</button>
    </div>
  );
}

export default App;
