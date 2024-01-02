import { Component, OnInit } from '@angular/core';
import { ContentService } from '../../services/content.service';
import { ContentDto } from '../../models/contentDto';
import { ContentSearchDto } from '../../models/contentSearchDto';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  contentDtos: ContentDto[] = []
  searchText: any;

  contentSearchDtos: ContentSearchDto[] = []
  filteredSearchTexts:any;
  constructor(private contentService: ContentService) {

  }

  ngOnInit(): void {
    this.contentService.contents().subscribe(rv => {
      this.contentDtos = rv.data
    })
  }

  search(searchText: any) {
    console.log(searchText)
    if (searchText.length > 2) {
      this.contentService.search(searchText).subscribe(rv => {
        console.log(rv)
        this.contentSearchDtos = rv.data;
        // this.contentDtos = rv.data
      })
    }else{
      this.contentSearchDtos = []
    }
  }

}
