import axios from 'axios';
import React, { useState } from 'react'
import { ICreateNoteRequest, INote } from '../data/models';
import { ErrorMessage } from './ErrorMessage';

interface ICreateNoteProps {
    onCreate: (note: INote) => void
}


export function CreateNote({ onCreate } : ICreateNoteProps) {
    const [title, setTitle] = useState("");
    const [content, setContent] = useState("");
    const [titleError, setTitleError] = useState("");
    const [contentError, setContentError] = useState("");

const noteDataRequest: ICreateNoteRequest = {
    title: '',
    content: ''
}

    const changeTitleHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
        setTitle(event.target.value);
    }

    const changeContentHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
        setContent(event.target.value);
    }


const submitHandler = async (event: React.FormEvent) => {
    event.preventDefault();
    setTitleError("");
    setContentError("");

    if(title.trim().length === 0){
        setTitleError("Please enter valid title.");
        return;
    }

    if(content.trim().length === 0){
        setContentError("Please enter valid content.");
        return;
    }

    noteDataRequest.title = title;
    noteDataRequest.content = content;

    const response = await axios.post<INote>("http://localhost:5222/api/notes/create", noteDataRequest);
    
    onCreate(response.data);
}

return (
    <form onSubmit={submitHandler}>
        <input type="text" className='border w-full py-2 px-4 mb-2' placeholder='Enter note title...'
            value={title} onChange={changeTitleHandler}  />
        {titleError && <ErrorMessage error={titleError} />}
        <input type="text" className='border w-full py-2 px-4 mb-2' placeholder='Enter note text here...'
            value={content} onChange={changeContentHandler}  />
        {contentError && <ErrorMessage error={contentError} />}
        <button type='submit' className='py-2 px-4 border bg-yellow-400'>Create note</button>
    </form>
)}