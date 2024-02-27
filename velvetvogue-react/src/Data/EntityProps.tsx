export type BrandProps = {
  id: number;
  name: string;
};

export type CategoryProps = {
  id: number;
  name: string;
};

export type ColorProps = {
  id: number;
  name: string;
};

export type SizeProps = {
  id: number;
  name: string;
};

export type StockProps = {
  id: number;
  productId: number;
  quantity: number;
};

export type ProductProps = {
  id: number;
  name: string;
  brandId: number;
  categoryId: number;
  colorId: number;
  sizeId: number;
  price: number;
  brand: BrandProps;
  category: CategoryProps;
  color: ColorProps;
  size: SizeProps;
  stock: StockProps;
};
