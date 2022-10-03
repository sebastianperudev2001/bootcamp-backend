import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { PersonService } from "../../../services/person.service";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit {
  formPerson: FormGroup;
  documentTypes: any[] = [];
  constructor(
    private formBuilder: FormBuilder,
    private personService: PersonService,
    private router: Router,
    private activatedRouter: ActivatedRoute
  ) {
    this.formPerson = formBuilder.group({
      id: [{ value: null, disabled: false }],
      name: [{ value: null, disabled: false }, [Validators.required]],
      lastname: [{ value: null, disabled: false }, [Validators.required]],
      documentNumber: [{ value: null, disabled: false }, [Validators.required]],
      documentTypeId: [{ value: null, disabled: false }, [Validators.required]],
      birthday: [{ value: null, disabled: false }, []],
    })
  }

  ngOnInit(): void {
    this.personService.getTypeDocument().subscribe(documentTypes => {
      this.documentTypes = documentTypes;
    })

    this.generateData();


  }
  cancelar(): void {
    this.back();
  }

  back(): void {
    this.router.navigate(['/person'], {
      relativeTo: this.activatedRouter
    })
  }

  guardar(): void {
    const person = this.formPerson.getRawValue();
    person.id = this.activatedRouter.snapshot.params['id']
    console.log(person)
    this.personService.update(person).subscribe(x => {
      alert("Se actualizó correctamente");
      this.back();
    })

  }

  generateData(): void {
    this.personService.getPersonID(this.activatedRouter.snapshot.params['id']).subscribe(x => {
      this.formPerson = this.formBuilder.group({
        name: [{ value: x.name, disabled: false }, [Validators.required]],
        lastname: [{ value: x.lastname, disabled: false }, [Validators.required]],
        documentNumber: [{ value: x.documentNumber, disabled: false }, [Validators.required]],
        documentTypeId: [{ value: x.documentTypeId, disabled: false }, [Validators.required]],
        birthday: [{ value: null, disabled: false }]
      })
    })
  }


}
