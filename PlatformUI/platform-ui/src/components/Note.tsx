import React, { useState } from 'react'
import { INote } from '../data/models'

interface INoteProps {
  note: INote
}

export function Note({note}: INoteProps) {
  return (
    <div
    className="border py-2 px-4 rounded flex flex-col items-center mb-2" >
        <h2>{ note.title }</h2>
        <p>{ note.content }</p>
        <p className='created'>{ new Date(note.creationDate).toDateString() }</p>
    </div>
  )
}
