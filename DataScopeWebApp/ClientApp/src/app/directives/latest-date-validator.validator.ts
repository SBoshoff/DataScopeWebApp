import { formatDate } from "@angular/common";
import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

/**
 * A validator function to ensure that the release date of a game can be no newer than the current date
 * @returns A validator function
 */
export function LatestDateValidator() : ValidatorFn{
    return (control: AbstractControl): ValidationErrors | null => {
        var maxDate = formatDate(new Date(), 'yyyy-MM-dd', 'en-US');
        const older = Date.parse(maxDate) < Date.parse(control.value);
        return older ? {forbiddenName: {value: control.value}} : null;
      };
}