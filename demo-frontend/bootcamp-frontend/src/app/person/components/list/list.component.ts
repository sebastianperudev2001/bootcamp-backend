import { Component, OnInit } from '@angular/core';
import { PersonService } from "../../../services/person.service";
import { MatTableDataSource } from "@angular/material/table";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'lastname', 'documentType', 'documentNumber', 'birthday', 'actions'];
  personDataSource: MatTableDataSource<any> = new MatTableDataSource<any>();

  constructor(
    private personService: PersonService,
    private router: Router, //Moverte entre rutas
    private activatedRoute: ActivatedRoute //En que rutas estás 
  ) {
  }

  ngOnInit(): void {
    this.getPerson();
  }

  getPerson(): void {
    this.personService.getAll().subscribe(listPerson => {
      this.personDataSource.data = listPerson;
    })
  }

  editarPerson(person: any): void {
    this.router.navigate(
      ['/person/update/' + person.id],
      { relativeTo: this.activatedRoute })

  }


  deletePerson(person: any): void {
    //alert('Eliminado persona ' + person.name)
    this.personService.delete(person.id).subscribe(response => {
      console.log(response);
      this.getPerson()
    })

  }

  agregarPerson(): void {
    this.router.navigate(['./create'], {
      relativeTo: this.activatedRoute
    })
  }
}