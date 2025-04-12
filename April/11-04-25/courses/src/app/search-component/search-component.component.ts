import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-search-component',
  standalone: false,
  templateUrl: './search-component.component.html',
  styleUrl: './search-component.component.css'
})
export class SearchComponentComponent {

  @Output() 
  search: EventEmitter<any> = new EventEmitter<any>();
  searchText = '';

  onSearchChange() {
    this.search.emit(this.searchText);
  }

}
