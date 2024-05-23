export class Photo{
    constructor(data){
        this.id = data.id
        this.title = data.title
        this.description = data.description
        this.img = data.img
        this.createdAt = new Date(data.createdAt).toLocaleDateString()
        this.updatedAt = new Date(data.updatedAt).toLocaleTimeString()
        this.creator = data.creator
        this.creatorId = data.creatorId
    }
}