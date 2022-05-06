import {FormGroup} from "@angular/forms";

export class BasePageModel {
  public title: string | undefined;
  public lastInsertId: number | undefined;
  public itemList: any[] | undefined;
  public foundItem: any | undefined;
  public deletedItem: any | undefined;

  public insertForm: FormGroup | undefined;
  public findForm: FormGroup | undefined;
  public updateForm: FormGroup | undefined;
  public deleteForm: FormGroup | undefined;
}
