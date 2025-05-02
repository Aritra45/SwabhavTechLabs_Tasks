import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-search',
  standalone: false,
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent {
  @Output() searchChanged = new EventEmitter<string>();

  onSearchChange(event: Event) {
    const input = event.target as HTMLInputElement;
    this.searchChanged.emit(input.value.trim());
  }
}
