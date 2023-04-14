import axios, { AxiosError } from "axios";
import { useEffect, useState } from "react";
import { INote } from "../data/models";

export function useNotes() {
    const [notes, setNotes] = useState<INote[]>([])
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState('');

    function addNote(note: INote) {
        setNotes(prev => [...notes, note]);
    }

    function deleteNote(note: INote) {
        var index = notes.indexOf(note);
        if(index >= 0){
            notes.splice(index, 1);
            setNotes(prev => [...notes]); 
        }
    }

    async function fetchNotes() {
        try {
            setError('');
            setLoading(true);
            const response = await axios.get<INote[]>("http://localhost:5279/api/notes");
            setNotes(response.data);
            setLoading(false);
        } catch (e: unknown) {
            const error = e as AxiosError;
            setLoading(false);
            setError(error.message);
        }
    }

    useEffect(() => {
        fetchNotes();
    }, [])

    return { notes, loading, error, addNote, deleteNote };
}