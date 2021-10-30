import { Faculty } from "../faculty/faculty.model";

export interface StudentGroupFullInfo {
    id: number,
    title: string,
    facultyId: number | null,
    faculty: Faculty,
    startYear: number,
    endingYear: number
}