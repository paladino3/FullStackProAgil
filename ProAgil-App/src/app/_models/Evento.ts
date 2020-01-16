import { Lote } from './Lote';
import { RedeSocial } from './RedeSocial';
import { Palestrante } from './Palestrante';

export interface Evento {
id: number;
local: string;
lotes: Lote[];
dataEvento: Date;
tema: string;
qtdePessoas: number;
imagemUrl: string;
telefone: string;
email: string;
list: Lote[];
redeSociais: RedeSocial[];
palestranteEventos: Palestrante[];

}
