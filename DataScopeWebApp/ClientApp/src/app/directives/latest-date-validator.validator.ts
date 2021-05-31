import { formatDate } from "@angular/common";
import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function LatestDateValidator() : ValidatorFn{
    return (control: AbstractControl): ValidationErrors | null => {
        var maxDate = formatDate(new Date(), 'yyyy-MM-dd', 'en-US');
        const older = Date.parse(maxDate) < Date.parse(control.value);
        return older ? {forbiddenName: {value: control.value}} : null;
      };
}