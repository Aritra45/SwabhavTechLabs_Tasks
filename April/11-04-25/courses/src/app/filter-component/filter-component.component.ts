import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-filter-component',
  standalone: false,
  templateUrl: './filter-component.component.html',
  styleUrl: './filter-component.component.css'
})
export class FilterComponentComponent {
  @Output() 
  filterChange: EventEmitter<any> = new EventEmitter<any>();
  selected = 'all';

  onFilterChange() {
    this.filterChange.emit(this.selected);
  }

}
