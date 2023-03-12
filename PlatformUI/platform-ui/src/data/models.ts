export interface INote {
    id: string
    title: string
    content: string
    creationDate: string
    editDate: string
} 

export interface ICreateNoteRequest {
    title: string
    content: string
}