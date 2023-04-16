import axios from 'axios';
import { INote } from '../data/models'
import delete_icon from '../icons/delete.png'

interface INoteProps {
  note: INote,
  onDelete: (note: INote) => void
}

export function Note({note, onDelete}: INoteProps) {

  const deleteNoteHandler = async () => {
    const response = await axios.delete("http://localhost:5222/api/notes/" + note.id);
    onDelete(note);
  }

  return (
    <div
    className="border py-2 px-4 rounded flex items-center mb-2" >
        <div className="noteContent grow">
        <h2>{ note.title }</h2>
        <p>{ note.content }</p>
        <p className='created'>{ new Date(note.creationDate).toDateString() }</p>
        </div>
        <div className='deleteNote flex-none'>
          <button className="w-8 h-8" onClick={() => deleteNoteHandler()}><img src={ delete_icon } alt="Del"></img></button>
        </div>
    </div>
  )
}
