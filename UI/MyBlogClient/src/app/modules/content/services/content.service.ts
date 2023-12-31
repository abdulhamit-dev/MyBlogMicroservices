import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ReturnObject } from 'src/app/core/models/returnObject';
import { HttpHelperService } from 'src/app/core/services/app.service';
import { CommentDto } from '../models/commentDto';
import { User } from 'src/app/core/models/user';
import { ContentUpdateDto } from '../models/contentUpdateDto';
import { LikesDto } from '../models/likesDto';


@Injectable({
  providedIn: 'root'
})
export class ContentService {

  constructor(private httpHelperService: HttpHelperService) { }

  contents(): Observable<ReturnObject> {
    return this.httpHelperService.get("content/content/getall")
  }

  search(search:string): Observable<ReturnObject> {
    return this.httpHelperService.get("textsearch/content/search?searchText="+search)
  }

  contentByCategoryId(id: string): Observable<ReturnObject> {
    return this.httpHelperService.get("content/content/GetAllByCategoryName?categoryId=" + id)
  }

  contentByUserId(id: string): Observable<ReturnObject> {
    return this.httpHelperService.get("content/content/GetAllByUserId?userId=" + id)
  }

  contentDetaild(id: string): Observable<ReturnObject> {
    return this.httpHelperService.get("content/content/GetById?id=" + id)
  }

  sendComment(commentDto: CommentDto) {
    return this.httpHelperService.post("comment/comment/Create", commentDto)
  }

  sendLike(likeDto: LikesDto) {
    return this.httpHelperService.post("reaction/reaction/like", likeDto)
  }

  getUser(){
    return JSON.parse(localStorage.getItem("user")!) as User
  }

  createContent(content:any){
    return this.httpHelperService.post("content/content/create",content);
  }

  upload(file:any){
    return this.httpHelperService.post('imagesstore/image/upload',file);
  }

  updateContent(content:ContentUpdateDto){
    return this.httpHelperService.post('content/content/Update',content)
  }

}
